<template>
  <div class="Vault container">
    <div class="d-flex flex-row justify-content-between">
      <h2 class="pointer" @click="goBack"><i class="fas fa-chevron-left"></i></h2>
      <h1 class="logo">{{activeVault.name}}</h1>
      <span></span>
    </div>
    <div class="card-columns">
      <div v-for="vaultkeep in vaultkeeps" class="card pointer" @click="setActiveKeep(vaultkeep)" data-toggle="modal"
        data-target=".bd-example-modal-lg">
        <img :src="vaultkeep.img" class="card-img-top">
        <div class="card-body">
          <p class="card-text">{{vaultkeep.name}}<span class="ml-2 opaque" v-if="vaultkeep.isPrivate == true"
              title="Private"><i class="fas fa-lock"></i></span>
          </p>
        </div>
        <div class="card-img-overlay">
          <p class="text-right opaque" @click.stop="removeVK(vaultkeep)"><i class="fas fa-times"></i></p>
        </div>
      </div>
    </div>
    <keepviewmodal></keepviewmodal>
  </div>
</template>

<script>
  import keepviewmodal from '@/components/keepviewmodal.vue'
  import router from '@/router.js'
  export default {
    name: "Vault",
    props: [],
    data() {
      return {}
    },
    computed: {
      activeVault() {
        return this.$store.state.activeVault
      },
      vaultkeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {
      goBack() {
        router.push({ name: "dashboard" })
      },
      setActiveKeep(keep) {
        this.$store.dispatch('setActiveKeep', keep)
        keep.views++
        this.$store.dispatch('editKeep', keep)
      },
      removeVK(keep) {
        debugger
        this.$store.dispatch('deleteVK', { keepId: keep.id, vaultId: this.activeVault.id })
      }
    },
    components: {
      keepviewmodal
    }
  }
</script>

<style>
  .opaque {
    color: #fff;
    text-shadow: 0 0 5px black;
  }
</style>