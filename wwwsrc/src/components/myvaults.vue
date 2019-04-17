<template>
  <div class="myvaults container">
    <div class="row">
      <div v-for="vault in vaults" class="col-12 col-md-4">
        <div class="card pointer mb-2" @click="setActiveVault(vault)">
          <div class="card-body">
            <h4 class="card-title logo">{{vault.name}}</h4>
            <hr>
            <p class="card-text">{{vault.description}}
            </p>
            <p class="pointer"><i @click.stop="deleteVault(vault)" class="far fa-trash-alt"></i></p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import router from '@/router.js'
  export default {
    name: "myvaults",
    props: [],
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      setActiveVault(vault) {
        this.$store.dispatch('setActiveVault', vault)
        router.push({ name: 'vault' })
      },
      deleteVault(vault) {
        this.$store.dispatch('deleteVault', vault)
      }
    },
    components: {}
  }
</script>