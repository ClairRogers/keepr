<template>
  <div class="mykeeps container">
    <div class="card-columns">
      <div v-for="keep in keeps" class="card pointer" @click="setActiveKeep(keep)" data-toggle="modal"
        data-target=".bd-example-modal-lg">
        <img :src="keep.img" class="card-img-top">
        <div class="card-body">
          <p class="card-text">{{keep.name}}
          </p>
        </div>
      </div>
    </div>
    <keepviewmodal></keepviewmodal>
  </div>
</template>

<script>
  import keepviewmodal from '@/components/keepviewmodal.vue'
  export default {
    name: "mykeeps",
    props: [],
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      keeps() {
        return this.$store.state.keeps.filter(k => k.userId == this.user.id)
      }
    },
    methods: {
      setActiveKeep(keep) {
        this.$store.dispatch('setActiveKeep', keep)
      }
    },
    components: {
      keepviewmodal
    }
  }
</script>